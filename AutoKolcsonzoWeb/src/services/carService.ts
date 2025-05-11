


import React, { useState, useEffect } from "react";

export interface Car {
  id: number;
  licensePlate: string;
  picture: string;
  brand: string;
  type: string;
  year: string;
  drive: string;
  gearShift: string;
  fuel: string;
  airCondition: boolean;
  radar: boolean;
  cruiseControl: boolean;
  info: string;
  category: string;
  OneToFive: number;
  SixToForteen: number;
  OverForteen: number;
  Deposit: number;

}

function App() {
  const [cars, setCars] = useState<Car[]>([]);

  async function loadCars() {
    try {
      const response = await fetch("http://127.1.1.1:3000/listCars");
      if (!response.ok) {
        throw new Error(`Error: ${response.status} - ${response.statusText}`);
      }
      const data: Car[] = await response.json();
      setCars(data);
    } catch (error) {
      console.error("Failed to load cars:", error);
    }
  }

  // Trigger loading when the component is mounted
  useEffect(() => {
    loadCars();
  }, []);

  return cars;
}

export default App;

// Car service functions
// Extracted constant for delay configuration
const DEFAULT_DELAY = 300;

// Renamed for better clarity and added explicit generic type
const simulateDelay = <T>(data: T, delay: number = DEFAULT_DELAY): Promise<T> => {
  return new Promise((resolve) => setTimeout(() => resolve(data), delay));
};



// Refactored main functions with extracted constant and reusable logic
export const getAllCars = (): Promise<Car[]> => simulateDelay([]);

export const getCarById = (id: number): Promise<Car | undefined> => {
  return new Promise((resolve) => {
    // Simulate network delay
    setTimeout(() => {
      const car = getAllCars().then((cars) => cars.find((car) => car.id === id));
      resolve(car);
    }, 300);
  });
};


