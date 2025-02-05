const {Sequelize, DataTypes} = require('sequelize')
const dbHandler = new Sequelize(
    "autoBerles",
    "root",
    "",
    {
        host: "localhost",
        dialect: "mysql"
    }
)

exports.adminTable = dbHandler.define(
    "admin",{
        "id":{
            type: DataTypes.INTEGER,
            primaryKey: true,
            autoIncrement: true
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
    }
)

exports.personalTable = dbHandler.define(
    "personalInfo",{
        "id":{
            type: DataTypes.INTEGER,
            primaryKey: true,
            autoIncrement: true
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
    }
)

exports.userTable = dbHandler.define(
    "user",{
        "id":{
            type: DataTypes.INTEGER,
            primaryKey: true,
            autoIncrement: true
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
    }
)

exports.carsTable = dbHandler.define(
    "cars",{
        "id":{
            type: DataTypes.INTEGER,
            primaryKey: true,
            autoIncrement: true
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
        "fule":{
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
        "place":{
            type: DataTypes.STRING,
            allowNull: false
        },
        "info":{
            type: DataTypes.STRING,
            allowNull: false
        }
    }
)

exports.reservationTable = dbHandler.define(
    "reservation",{
        "id":{
            type: DataTypes.INTIGER,
            primaryKey: true,
            autoIncrement: true
        },
        "carId":{
            type: DataTypes.INTIGER,
            primaryKey: true,
            autoIncrement: true
        },
        "personId":{
            type: DataTypes.INTIGER,
            primaryKey: true,
            autoIncrement: true
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
    }
)