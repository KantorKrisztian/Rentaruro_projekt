package com.example.rentaruro.model

import com.google.gson.annotations.SerializedName

data class Car(
  val id: Int,
  val licensePlate: String?,
  val picture: String,
  val brand: String,
  @SerializedName("type") val model: String,
  val year: Int,
  val drive: String,
  val gearShift: String,
  val fuel: String,
  val airCondition: Boolean,
  val radar: Boolean,
  val cruiseControl: Boolean,
  val info: String,
  val category: String,
  @SerializedName("OneToFive") val oneToFive: Int,
  @SerializedName("SixToForteen") val sixToForteen: Int,
  @SerializedName("OverForteen") val overForteen: Int,
  val Deposit: Int
)
