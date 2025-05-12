


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
function carService() {
  const [cars, setCars] = useState([])

  function load() {
    const loadRequest = new XMLHttpRequest();
    loadRequest.open("get", "http://127.1.1.1:3000/ListCars");
    loadRequest.send();
    loadRequest.onreadystatechange = () => {
      if (loadRequest.readyState === 4 && loadRequest.status === 200) {
        const result = JSON.parse(loadRequest.response); // Raw response
        const cars: Car[] = result.map((car: any) => ({
          id: car.id,
          licensePlate: car.licensePlate,
          picture: car.picture,
          brand: car.brand,
          type: car.type,
          year: car.year,
          drive: car.drive,
          gearShift: car.gearShift,
          fuel: car.fuel,
          airCondition: car.airCondition,
          radar: car.radar,
          cruiseControl: car.cruiseControl,
          info: car.info,
          category: car.category,
          OneToFive: car.OneToFive,
          SixToForteen: car.SixToForteen,
          OverForteen: car.OverForteen,
          Deposit: car.Deposit,
        }));
        setCars(cars);
      }
    };
  }
  useEffect(() => {
    load();
  }, []);
return setCars;
}




