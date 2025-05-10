package com.example.rentaruro.repository

import com.example.rentaruro.model.Car
import com.example.rentaruro.network.ApiService
import com.example.rentaruro.network.RetrofitClient.apiService


class CarRepository() {
    suspend fun getCars(): List<Car> {
        return apiService.listCars()
    }
}

private fun ApiService.listCars(): List<Car> {
    TODO("Not yet implemented")
}


