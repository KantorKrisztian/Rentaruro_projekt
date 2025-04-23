
// Mock database for car data
const carsData = [
  {
    id: 1,
    name: "Toyota Corolla",
    price: "10.500 Ft/nap",
    imageUrl: "/placeholder.svg",
    priceTable: {
      "1 - 5 nap": "10.500 Ft /nap",
      "6 - 14 nap": "10.500 Ft /nap",
      "15 naptól": "9.000 Ft /nap",
      "1 hónap": "225.000 Ft /hó",
      "Kaució": "50.000 Ft"
    },
    specs: {
      fuel: "Benzin",
      transmission: "Manuális"
    }
  },
  {
    id: 2,
    name: "Honda Civic",
    price: "9.000 Ft/nap",
    imageUrl: "/placeholder.svg",
    priceTable: {
      "1 - 5 nap": "9.000 Ft /nap",
      "6 - 14 nap": "9.000 Ft /nap",
      "15 naptól": "8.000 Ft /nap",
      "1 hónap": "210.000 Ft /hó",
      "Kaució": "50.000 Ft"
    },
    specs: {
      fuel: "Benzin",
      transmission: "Manuális"
    }
  },
  {
    id: 3,
    name: "Ford Focus",
    price: "9.500 Ft/nap",
    imageUrl: "/placeholder.svg",
    priceTable: {
      "1 - 5 nap": "9.500 Ft /nap",
      "6 - 14 nap": "9.000 Ft /nap",
      "15 naptól": "8.500 Ft /nap",
      "1 hónap": "215.000 Ft /hó",
      "Kaució": "50.000 Ft"
    },
    specs: {
      fuel: "Dízel",
      transmission: "Manuális"
    }
  },
  {
    id: 4,
    name: "Volkswagen Golf",
    price: "11.000 Ft/nap",
    imageUrl: "/placeholder.svg",
    priceTable: {
      "1 - 5 nap": "11.000 Ft /nap",
      "6 - 14 nap": "10.500 Ft /nap",
      "15 naptól": "9.500 Ft /nap",
      "1 hónap": "235.000 Ft /hó",
      "Kaució": "60.000 Ft"
    },
    specs: {
      fuel: "Benzin",
      transmission: "Automata"
    }
  },
  {
    id: 5,
    name: "Skoda Octavia",
    price: "10.000 Ft/nap",
    imageUrl: "/placeholder.svg",
    priceTable: {
      "1 - 5 nap": "10.000 Ft /nap",
      "6 - 14 nap": "9.500 Ft /nap",
      "15 naptól": "9.000 Ft /nap",
      "1 hónap": "220.000 Ft /hó",
      "Kaució": "50.000 Ft"
    },
    specs: {
      fuel: "Dízel",
      transmission: "Manuális"
    }
  },
  {
    id: 6,
    name: "Hyundai i30",
    price: "8.500 Ft/nap",
    imageUrl: "/placeholder.svg",
    priceTable: {
      "1 - 5 nap": "8.500 Ft /nap",
      "6 - 14 nap": "8.000 Ft /nap",
      "15 naptól": "7.500 Ft /nap",
      "1 hónap": "200.000 Ft /hó",
      "Kaució": "40.000 Ft"
    },
    specs: {
      fuel: "Benzin",
      transmission: "Manuális"
    }
  },
  {
    id: 7,
    name: "Mazda 3",
    price: "11.500 Ft/nap",
    imageUrl: "/placeholder.svg",
    priceTable: {
      "1 - 5 nap": "11.500 Ft /nap",
      "6 - 14 nap": "11.000 Ft /nap",
      "15 naptól": "10.000 Ft /nap",
      "1 hónap": "240.000 Ft /hó",
      "Kaució": "60.000 Ft"
    },
    specs: {
      fuel: "Benzin",
      transmission: "Automata"
    }
  },
  {
    id: 8,
    name: "Kia Ceed",
    price: "9.200 Ft/nap",
    imageUrl: "/placeholder.svg",
    priceTable: {
      "1 - 5 nap": "9.200 Ft /nap",
      "6 - 14 nap": "8.700 Ft /nap",
      "15 naptól": "8.200 Ft /nap",
      "1 hónap": "210.000 Ft /hó",
      "Kaució": "45.000 Ft"
    },
    specs: {
      fuel: "Benzin",
      transmission: "Manuális"
    }
  }
];

// Type definitions
export interface Car {
  id: number;
  name: string;
  price: string;
  imageUrl: string;
  priceTable: Record<string, string>;
  specs: {
    fuel: string;
    transmission: string;
  };
}

// Car service functions
export const getAllCars = (): Promise<Car[]> => {
  return new Promise((resolve) => {
    // Simulate network delay
    setTimeout(() => {
      resolve(carsData);
    }, 300);
  });
};

export const getCarById = (id: number): Promise<Car | undefined> => {
  return new Promise((resolve) => {
    // Simulate network delay
    setTimeout(() => {
      const car = carsData.find((car) => car.id === id);
      resolve(car);
    }, 300);
  });
};
