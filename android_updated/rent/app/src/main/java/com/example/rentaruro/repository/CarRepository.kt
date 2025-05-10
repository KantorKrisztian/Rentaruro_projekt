package com.example.rentaruro.repository

import com.example.rentaruro.model.Car
import com.google.firebase.appdistribution.gradle.ApiService

class CarRepository(private val apiService: com.google.firebase.appdistribution.gradle.ApiService) {
    suspend fun getCars(): List<Car> {
        return apiService.listCars()
    }
}

private fun ApiService.listCars(): List<Car> {
    TODO("Not yet implemented")
}


