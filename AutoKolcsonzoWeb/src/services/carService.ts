


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

  useEffect(() => {
    loadCars();
  }, []);

  return cars;
}

export default App;

const DEFAULT_DELAY = 300;

const simulateDelay = <T>(data: T, delay: number = DEFAULT_DELAY): Promise<T> => {
  return new Promise((resolve) => setTimeout(() => resolve(data), delay));
};



export const getAllCars = (): Promise<Car[]> => simulateDelay([]);

export const getCarById = (id: number): Promise<Car | undefined> => {
  return new Promise((resolve) => {

    setTimeout(() => {
      const car = getAllCars().then((cars) => cars.find((car) => car.id === id));
      resolve(car);
    }, 300);
  });
};


