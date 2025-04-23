
import React, { useState, useEffect } from "react";
import { useQuery } from "@tanstack/react-query";
import CarCard from "./CarCard";
import { getAllCars, Car } from "../services/carService";

const CarGrid = () => {
  const { data: cars, isLoading, error } = useQuery({
    queryKey: ["cars"],
    queryFn: getAllCars
  });

  if (isLoading) {
    return (
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
        <div className="flex justify-center items-center h-64">
          <div className="text-gray-600">Autók betöltése...</div>
        </div>
      </div>
    );
  }

  if (error) {
    return (
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
        <div className="flex justify-center items-center h-64">
          <div className="text-red-500">Hiba történt az adatok betöltésekor.</div>
        </div>
      </div>
    );
  }

  return (
    <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
      <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
        {cars?.map((car: Car) => (
          <CarCard
            key={car.id}
            id={car.id}
            name={car.name}
            price={car.price}
            imageUrl={car.imageUrl}
          />
        ))}
      </div>
    </div>
  );
};

export default CarGrid;
