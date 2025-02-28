const {Sequelize, DataTypes} = require('sequelize')
require('dotenv').config()
const DBNAME = process.env.DBNAME
const USERNAME = 'root'
const PASSWORD = process.env.PASSWORD
const HOST = process.env.HOST

const dbHandler = new Sequelize(DBNAME,USERNAME,PASSWORD,
    {
        host: HOST,
        dialect: "mysql"
    }
)

class admin extends Model {}

admin.init({
    "id":{
        type: DataTypes.INTEGER,
        primaryKey: true,
        autoIncrement: true,
        allowNull: false
    },
    "username":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "password":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "role":{
        type: DataTypes.STRING,
        allowNull: false
    }
},{
    sequelize:dbHandler, modelName:'admin'
})

exports.adminTable = admin

class personalInfo extends Model {}

personalInfo.init({
    "id":{
        type: DataTypes.INTEGER,
        primaryKey: true,
        autoIncrement: true,
        allowNull: false
    },
    "name":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "address":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "email":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "phone":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "birth":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "tax":{
        type: DataTypes.STRING,
        allowNull: false
    }
},{
    sequelize:dbHandler, modelName:'personalInfo'
})

exports.personalTable = personalInfo

class user extends Model {}

user.init({
    "id":{
        type: DataTypes.INTEGER,
        primaryKey: true,
        autoIncrement: true,
        allowNull: false
    },
    "username":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "password":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "phone":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "email":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "name":{
        type: DataTypes.STRING,
        allowNull: false
    }
},{
    sequelize:dbHandler, modelName: 'user'
})

exports.userTable = user

class cars extends Model {}

cars.init({
    "id":{
        type: DataTypes.INTEGER,
        primaryKey: true,
        autoIncrement: true,
        allowNull: false
    },
    "picture":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "brand":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "type":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "year":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "drive":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "drive":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "gearShift":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "fuel":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "airCondition":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "radar":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "cruiseControl":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "info":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "location":{
        type: DataTypes.STRING,
        allowNull: false
    }
},{
    sequelize:dbHandler, modelName: 'cars'
})

exports.carsTable = cars

class reservation extends Model {}

reservation.init({
    "id":{
        type: DataTypes.INTIGER,
        primaryKey: true,
        autoIncrement: true,
        allowNull: false
    },
    "carId":{
        type: DataTypes.INTIGER,
        primaryKey: true,
        allowNull: false
    },
    "personId":{
        type: DataTypes.INTIGER,
        primaryKey: true,
        allowNull: false
    },
    "start":{
        type: DataTypes.DATE,
        allowNull: false
    },
    "end":{
        type: DataTypes.DATE,
        allowNull: false
    },
    "other":{
        type: DataTypes.STRING,
        allowNull: false
    }
},{
    sequelize:dbHandler, modelName: 'reservation'
})

exports.reservationTable = reservation

