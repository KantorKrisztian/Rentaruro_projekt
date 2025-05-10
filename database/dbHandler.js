const {Sequelize, Model,DataTypes} = require('sequelize')
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
    },
    "realName":{
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
        type: DataTypes.DATE,
        allowNull: false
    },
    "tax":{
        type: DataTypes.STRING,
        allowNull: false
    }
},{
    sequelize:dbHandler, modelName:'admin'
})



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



class cars extends Model {}

cars.init({
    "id":{
        type: DataTypes.INTEGER,
        primaryKey: true,
        autoIncrement: true,
        allowNull: false
    },
    "licensePlate":{
        type: DataTypes.STRING,
        allowNull: true
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
        type: DataTypes.INTEGER,
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
        type: DataTypes.BOOLEAN,
        allowNull: false
    },
    "radar":{
        type: DataTypes.BOOLEAN,
        allowNull: false
    },
    "cruiseControl":{
        type: DataTypes.BOOLEAN,
        allowNull: false
    },
    "info":{
        type: DataTypes.STRING(3000),
        allowNull: false
    },
    "category":{
        type: DataTypes.STRING,
        allowNull: false
    },
    "OneToFive":{
        type: DataTypes.INTEGER,
        allowNull: false
    },
    "SixToForteen":{
        type: DataTypes.INTEGER,
        allowNull: false
    },
    "OverForteen":{
        type: DataTypes.INTEGER,
        allowNull: false
    },
    "Deposit":{
        type: DataTypes.INTEGER,
        allowNull: false
    }
},{
    sequelize:dbHandler, modelName: 'cars'
})



class reservation extends Model {}

reservation.init({
    "id":{
        type: DataTypes.INTEGER,
        primaryKey: true,
        autoIncrement: true,
        allowNull: false
    },
    "carId":{
        type:DataTypes.INTEGER,
        allowNull:false,
        references:{
            model: cars,
            key:'id'
        }
    },
    "personId":{
        type: DataTypes.INTEGER,
        allowNull: false,
        references:{
            model: user,
            key:'id'
        }
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






reservation.belongsTo(cars,{
    foreignKey:'carId',
    targetKey:'id'
})

reservation.belongsTo(user,{
    foreignKey:'personId',
    targetKey:'id'
})

exports.adminTable = admin
exports.userTable = user
exports.carsTable = cars
exports.reservationTable = reservation