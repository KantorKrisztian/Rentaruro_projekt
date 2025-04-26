const express = require('express')
const server = express()
require('dotenv').config()

server.use(express.json())
server.use(express.static('public'))
const PORT = process.env.PORT

const JWT = require('jsonwebtoken')

const timeLimit = '1h'
const SUPERSECRET = process.env.SECRETKEY


const dbHandler = require('./dbHandler')
async function database(){
    await dbHandler.adminTable.sync({alter:true})
    await dbHandler.carsTable.sync({alter:true})
    await dbHandler.userTable.sync({alter:true})
    await dbHandler.reservationTable.sync({alter:true})
    await createAdmin()
}
database()
function auth() {
    return (req,res,next)=>{
        const authenticate=req.headers.authorization
        if (typeof(authenticate)=='undefined') {
            res.status(401)
            res.json({"message":"Nem létező token"})
            res.end()
            return
        }
        if (!authenticate.startsWith("Bearer")) {
            res.status(401)
            res.json({"message":"Hibás token"})
            res.end()
            return
        }
        
        const encodedToken=authenticate.split('__')[1]
        try {
            const decodedToken=JWT.verify(encodedToken,SUPERSECRET)
            req.username=decodedToken.username
            req.id=decodedToken.id
            next()
        } catch (error) {
            res.json({"message":error})
            res.end()
        }
    }
}


server.get("/ListAllRents",async (req,res)=>{
    try {
        const reservations = await dbHandler.reservationTable.findAll()
        const cars = await dbHandler.carsTable.findAll()
        const asd = await dbHandler.userTable.findAll()
        
        const detailedReservations = reservations.map((reservation) => {
            const car = cars.find((car) => car.id === reservation.carId)
            const user = asd.find((user) => user.id === reservation.personId)
            
            return {
                id: reservation.id,
                start: reservation.start,
                end: reservation.end,
                other: reservation.other,
                carId: reservation.carId,
                licensePlate: car?.licensePlate,
                brand: car?.brand,
                type: car?.type,
                personId: user?.id,
                username: user?.username,
                name: user?.name,
                email: user?.email,
                phone: user?.phone,
            }
        })

        res.json(detailedReservations).end()
    } catch (error) {
        res.status(500).json({ "message": error }).end()
    }
})

server.post("/NewRent",auth(),async (req,res)=>{
    let oneRent
    try {
        oneRent=await dbHandler.reservationTable.findOne({
            where:{
                carId:req.body.carId,
                [dbHandler.Sequelize.Op.or]: [
                    {
                        start: {
                            [dbHandler.Sequelize.Op.between]: [req.body.start, req.body.end]
                        }
                    },
                    {
                        end: {
                            [dbHandler.Sequelize.Op.between]: [req.body.start, req.body.end]
                        }
                    },
                    {
                        [dbHandler.Sequelize.Op.and]: [
                            { start: { [dbHandler.Sequelize.Op.lte]: req.body.start } },
                            { end: { [dbHandler.Sequelize.Op.gte]: req.body.end } }
                        ]
                    }
                ]
            }
            
        })
        if (oneRent) {
            res.status(409).json({ message: "Ebben az időben már foglalt ez az autó." })
            return
        }
        await dbHandler.reservationTable.create({
            carId:req.body.carId,
            userId:req.id,
            start:req.body.start,
            end:req.body.end,
            other:req.body.other
        });
        res.status(201).json({ message: "Sikeres foglalás!" });
        res.end()
        return
    } catch (error) {
        res.json({'message':error})
        res.end()
    }
})

server.put("/UpdateRent/:id",auth(),async (req,res)=>{
    let oneRent
    try {
        oneRent=await dbHandler.reservationTable.findOne({
            where:{
                id:req.params.id
            }
        })
        if (!oneRent) {
            res.status(404).json({"message":"Nem található ilyen foglalás!"}).end()
            return
        }
    } catch (error) {
        res.json({"message":error}).end()
        return
    }
    await dbHandler.reservationTable.update({
        start:req.body.start,
        end:req.body.end,
        other:req.body.other
    },{
        where:{
            id:req.params.id
        }
    })
    res.status(200).json({"message":"Sikeres frissítés!"})
})

server.delete("/DeleteRent/:id",auth(),async (req,res)=>{
    let oneRent
    try {
        oneRent=await dbHandler.reservationTable.findOne({
            where:{
                id:req.params.id
            }
        })
        if (!oneRent) {
            res.status(404).json({"message":"Nem található ilyen foglalás!"}).end()
            return
        }
        dbHandler.reservationTable.destroy({
            where:{
                id:req.params.id
            }
        })
        res.status(200).json({"message":"Sikeres törlés!"}).end()
        return
    } catch (error) {
        res.json({"message":error}).end()
    }
})
server.get("/ListCars",async (req,res)=>{
    const cars = await dbHandler.carsTable.findAll()
    res.json(cars).end()
})

server.delete('/DeleteCar/:id',auth(),async (req,res)=>{
    let oneCar
    try {
        oneCar=await dbHandler.carsTable.findOne({
            where:{
                id:req.params.id
            }
        })
    } catch (error) {
        res.status(200).json({'message':error}).end()
        return
    }

    if (oneCar) {
        try {
            await dbHandler.carsTable.destroy({
                where: {
                    id:req.params.id
                }
            })
            res.json({"message":"Sikeres törlés!"})
            res.end()
            return
        } catch (error) {
            res.json({'message':error})
            res.end()
            return
        }
    }
    res.status(404)
    res.json({"message":"Nem létezik ezzel az id-val autó!"})
    res.end()
})


server.post("/AddCar",auth(),async (req,res)=>{
    let oneCar
    try {
        oneCar=await dbHandler.carsTable.findOne({
            where:{
                licensePlate:req.body.licensePlate
            }
        })
    } catch (error) {
        res.json({'message':error})
        res.end()
        return
    }
    if (oneCar) {
        res.status(409)
        res.json({"message":"Már létezik ezzel a rendszámmal autó!"})
        res.end()
        return
    }
    try {
        await dbHandler.carsTable.create({
            picture:req.body.picture,
            licensePlate:req.body.licensePlate,
            brand:req.body.brand,
            type:req.body.type,
            year:req.body.year,
            drive:req.body.drive,
            gearShift:req.body.gearShift,
            fuel:req.body.fuel,
            airCondition:req.body.airCondition,
            radar:req.body.radar,
            cruiseControl:req.body.cruiseControl,
            info:req.body.info,
            category:req.body.category,
            OneToFive:req.body.OneToFive,
            SixToForteen:req.body.SixToForteen,
            OverForteen:req.body.OverForteen,
            Deposit:req.body.Deposit
        })
    } catch (error) {
        res.json({'message':error})
        res.end()
        return
    }
    res.status(201)
    res.json({"message":"Sikeres hozzáadás!"})
    res.end()
})

server.put("/UpdateCar/:id",auth(),async (req,res)=>{
    
    let oneCar
    try {
        oneCar=await dbHandler.carsTable.findOne({
            where:{
                id:req.params.id
            }
        })
        if (!oneCar) {
            res.status(404)
            res.json({"message":"Nincs ilyen autó!"})
            res.end()
            return
        }
        await dbHandler.carsTable.update({
            picture:req.body.picture,
            licensePlate:req.body.licensePlate,
            brand:req.body.brand,
            type:req.body.type,
            year:req.body.year,
            drive:req.body.drive,
            gearShift:req.body.gearShift,
            fuel:req.body.fuel,
            airCondition:req.body.airCondition,
            radar:req.body.radar,
            cruiseControl:req.body.cruiseControl,
            info:req.body.info,
            category:req.body.category,
            OneToFive:req.body.OneToFive,
            SixToForteen:req.body.SixToForteen,
            OverForteen:req.body.OverForteen,
            Deposit:req.body.Deposit
        },{
            where:{
                id:req.params.id
            }
        })
        res.status(200).json({"message":"Sikeres módosítás"}).end()
        return
    } catch (error) {
        res.status(400).json({"message":error}).end()
    }
})


server.post("/AdminRegistration",auth(),async (req,res)=>{
    let oneUser
    try {
        oneUser=await dbHandler.adminTable.findOne({
            where:{
                username:req.body.username
            }
        })
    } catch (error) {
        res.json({'message':error})
        res.end()
        return
    }
    if (oneUser) {
        res.status(403)
        res.json({'message':'Ilyen felhasználó már van'})
        res.end()
        return
    }
    try {
        await dbHandler.adminTable.create({
            username:req.body.username,
            password:req.body.password,
            role:req.body.role,
            realName:req.body.realName,
            address:req.body.address,
            email:req.body.email,
            phone:req.body.phone,
            birth:req.body.birth,
            tax:req.body.tax
        })
    } catch (error) {
        res.json({'message':"error"})
        res.end()
        return
    }
    
    res.status(201)
    res.json({"message":"Sikeres regisztráció"})
    res.end()
})

server.post("/AdminLogin",async (req,res)=>{
    let oneUser
    try {
        oneUser=await dbHandler.adminTable.findOne({
            where:{
                username:req.body.loginNev,
                password:req.body.loginPassword
            }
        })
    } catch (error) {
        res.json({'message':error})
        res.end()
        return
    }

    if (oneUser) {
        try {
            const token=await JWT.sign({"username":oneUser.username,'id':oneUser.id},SUPERSECRET,{expiresIn:timeLimit})
            res.json({'message':'Sikeres bejelentkezés','token':token,'role':oneUser.role})
            res.end()
            return
        } catch (error) {
            res.json({'message':error})
            res.end()
            return
        }
    }

    res.status(409)
    res.json({"message":"Hibás felhasználónév, vagy jelszó"})
    res.end()
})

server.get("/ListAllWorkers",auth(),async (req,res)=>{
    const workers=await dbHandler.adminTable.findAll()
    res.status(200).json(workers).end()
})

server.delete("/DeleteWorker/:id",auth(),async (req,res)=>{
    try {
        const worker=await dbHandler.adminTable.findOne({
            where:{
                id:req.params.id
            }
        })
        if (!worker) {
            res.status(404).json({"message":"Nincs ilyen dolgozó!"}).end()
            return
        }
        await dbHandler.adminTable.destroy({
            where:{
                id:req.params.id
            }
        })
        res.status(200).json({"message":"Sikeres törlés!"}).end()
    } catch (error) {
        
    }
})

server.put("/UpdateWorker/:id",auth(),async (req,res)=>{
    let oneWorker
    try {
        oneWorker=await dbHandler.adminTable.findOne({
            where:{
                id:req.params.id
            }
        })
        if (!oneWorker) {
            res.status(404).json({"message":"Nincs ilyen dolgozó!"}).end()
            return
        }
        await dbHandler.adminTable.update({
            username:req.body.username,
            password:req.body.password,
            role:req.body.role,
            realName:req.body.realName,
            address:req.body.address,
            email:req.body.email,
            phone:req.body.phone,
            birth:req.body.birth,
            tax:req.body.tax
        },{
            where:{
                id:req.params.id
            }
        })
        res.status(200).json({"message":"Sikeres módosítás!"}).end()
    } catch (error) {
        res.status(500).json({"message":error}).end()
    }
})

async function createAdmin() {
    let admin
    try {
        admin =await dbHandler.adminTable.findOne({
            where: {
                username: "admin"
            }
        })
    } catch (error) {
        console.log(error)
        return
    }
    if (admin) {
        console.log("Admin már létezik")
        return
    }
    try {
        await dbHandler.adminTable.create({
            username:"admin",
            password:encodePassword("admin"),
            role:"admin",
            realName:"Admin Admin",
            address:"admin utca 1",
            email:"admin",
            birth:"2000-01-01",
            phone:"admin",
            tax:"admin"
        })
    } catch (error) {
        console.log(error)
        return
        
    }
    
}



function encodePassword(password) {
    const buffer = Buffer.from(password, 'utf-8');
    return buffer.toString('base64');
}
function decodePassword(encodedPassword) {
    const buffer = Buffer.from(encodedPassword, 'base64');
    return buffer.toString('utf-8');
}
server.listen(PORT)