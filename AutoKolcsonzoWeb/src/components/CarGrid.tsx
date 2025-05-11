
import React, { useState } from "react";
import { useQuery } from "@tanstack/react-query";
import CarCard from "./CarCard";
import { getAllCars, Car } from "../services/carService";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";

const CarGrid = () => {
  const [sortOrder, setSortOrder] = useState<"asc" | "desc" | "none">("none");
  
  const { data: cars, isLoading, error } = useQuery<Car[]>({
    queryKey: ["cars"],
    queryFn: getAllCars
  });

  const sortedCars = React.useMemo(() => {
    if (!cars || sortOrder === "none") return cars;
    
    return [...cars].sort((a, b) => {
      const priceA = parseInt(a.OneToFive.toString().replace(/[^0-9]/g, ""));
      const priceB = parseInt(b.OneToFive.toString().replace(/[^0-9]/g, ""));
      
      return sortOrder === "asc" ? priceA - priceB : priceB - priceA;
    });
  }, [cars, sortOrder]);

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
      <div className="mb-6 flex justify-end">
        <Select value={sortOrder} onValueChange={(value: "asc" | "desc" | "none") => setSortOrder(value)}>
          <SelectTrigger className="w-[200px]">
            <SelectValue placeholder="Rendezés ár szerint" />
          </SelectTrigger>
          <SelectContent>
            <SelectItem value="none">Alapértelmezett</SelectItem>
            <SelectItem value="asc">Ár szerint növekvő</SelectItem>
            <SelectItem value="desc">Ár szerint csökkenő</SelectItem>
          </SelectContent>
        </Select>
      </div>
      <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
        {sortedCars?.map((car: Car) => (
          <CarCard
            key={car.id}
            id={car.id}
            name={car.type}
            price={car.OneToFive}
            imageUrl={car.picture}
          />
        ))}
      </div>
    </div>
  );
};

export default CarGrid;
