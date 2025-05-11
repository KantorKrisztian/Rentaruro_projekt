package com.example.rentaruro.model

import com.google.gson.annotations.SerializedName

data class Car(
    val id: Int,
    val picture: String,
    val licensePlate: String?,
    val brand: String,
    val type: String,
    val year: Int,
    val drive: String,
    val gearShift: String,
    val fuel: String,
    val airCondition: Boolean,
    val radar: Boolean,
    val cruiseControl: Boolean,
    val info: String,
    val category: String,
    val OneToFive: Int,
    val SixToForteen: Int,
    val OverForteen: Int,
    val Deposit: Int
)
