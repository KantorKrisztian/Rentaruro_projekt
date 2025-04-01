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
dbHandler.adminTable.sync({alter:true})
dbHandler.personalTable.sync({alter:true})
dbHandler.userTable.sync({alter:true})
dbHandler.carsTable.sync({alter:true})
dbHandler.reservationTable.sync({alter:true})

function authorization() {
    return (req,res,next)=>{
        const auth=req.headers.authorization
        if (typeof(auth)=='undefined') {
            res.status(401)
            res.json({"message":"Nem létező token"})
            res.end()
            return
        }
        if (!auth.startsWith("Bearer")) {
            res.status(401)
            res.json({"message":"Hibás token"})
            res.end()
            return
        }
        const encodedToken=auth.split(' ')[1]
        try {
            const decodedToken=jwt.verify(encodedToken,SUPERSECRET)
            req.userName=decodedToken.nev
            req.userId=decodedToken.id
            next()
        } catch (error) {
            res.json({"message":error})
            res.end()
        }
    }
}

server.post("/AdminRegistration",async (req,res)=>{
    let oneUser
    try {
        oneUser=await dbHandler.adminTable.findOne({
            where:{
                username:req.body.registerNev
            }
        })
    } catch (error) {
        res.json({'message':error})
        res.end()
        console.log(error)
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
            username:req.body.registerNev,
            password:req.body.registerPassword,
            role:"dolgozo"
        })
    } catch (error) {
        res.json({'message':error})
        res.end()
        return
    }
    
    res.status(201)
    res.json({"message":"Sikeres regisztráció"})
    res.end()
})



server.post("/AddCar",async (req,res)=>{
    try {
        await dbHandler.carsTable.create({
            picture:req.body.picture,
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
            location:req.body.location,
            OneToFive:req.body.OneToFive,
            SixToForteen:req.body.SixToForteen,
            OverForteen:req.body.OverForteen,
            Deposit:req.body.Deposit
        })
    } catch (error) {
        res.json({'message':"error"})
        res.end()
        return
    }
    res.status(201)
    res.json({"message":"Sikeres hozzáadás!"})
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
            const token=await JWT.sign({"username":oneUser.nev,'id':oneUser.id},SUPERSECRET,{expiresIn:'1h'})
            res.json({'message':'Sikeres bejelentkezés','token':token})
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



server.get("/ListCars",async (req,res)=>{
    const cars = await dbHandler.carsTable.findAll()
    res.json(cars)
})

server.listen(PORT)