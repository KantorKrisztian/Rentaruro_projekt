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

function authenticate() {
    return (req,res,next) => {
        const token = req.headers.authorization
        if(!token || token.split(' ')[0].toLowerCase() != "bearer"){
            res.status(498)
            res.json({'message':'Hibás vagy nem létező bejelentkezési token'})
            res.end()
            return
        }
        const bearerToken = token.split(' ')[1]
        try{
            const decodedData = JWT.verify(bearerToken, SUPERSECRET)
            req.username = decodedData.username
            req.email = decodedData.email
            //??????
            next()
        }
        catch(error){
            res.json({'message':error})
            res.end()
        }
    }
}

function notUser(req,res,next){
    return (req,res,next) => {
        if(req.role != 'user'){
            next()
        }
        else{
            res.status(401)
            res.json({'message':'Belépés csak a személyzetnek!'})
            res.end()
        }
    }
}


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




server.listen(PORT)