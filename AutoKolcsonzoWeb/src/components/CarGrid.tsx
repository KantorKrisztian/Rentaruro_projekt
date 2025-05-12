
import React, { useState } from "react";
import { useQuery } from "@tanstack/react-query";
import CarCard from "./CarCard";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";

const CarGrid = () => {
  const [sortOrder, setSortOrder] = useState<"asc" | "desc" | "none">("none");
  const [cars, setCars] = useState([])

  function load() {
    const loadRequest = new XMLHttpRequest();
    loadRequest.open("get", "http://127.1.1.1:3000/ListCars");
    loadRequest.send()
    loadRequest.onreadystatechange = () => {
      if (loadRequest.readyState == 4 && loadRequest.status == 200) {
        const result = JSON.parse(loadRequest.response)
        setCars((cars) => result)
      }
    }
  }
load()


  const sortedCars = React.useMemo(() => {
    if (!cars || sortOrder === "none") return cars;
    
    return [...cars].sort((a, b) => {
      const priceA = parseInt(a.OneToFive.toString().replace(/[^0-9]/g, ""));
      const priceB = parseInt(b.OneToFive.toString().replace(/[^0-9]/g, ""));
      
      return sortOrder === "asc" ? priceA - priceB : priceB - priceA;
    });
  }, [cars, sortOrder]);



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
        {sortedCars?.map((car) => (
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
