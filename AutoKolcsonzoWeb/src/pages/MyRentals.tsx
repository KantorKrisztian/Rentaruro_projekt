
import React from "react";
import { useQuery } from "@tanstack/react-query";
import { Calendar, Package } from "lucide-react";
import Navbar from "@/components/Navbar";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";

// Define the rental type interface
interface Rental {
  id: number;
  carName: string;
  startDate: string;
  endDate: string;
  price: string;
}

// Mock rental data - this would typically come from an API
const mockRentals: Rental[] = [
  {
    id: 1,
    carName: "Volkswagen Golf",
    startDate: "2024-04-20",
    endDate: "2024-04-25",
    price: "75000 Ft",
  },
  {
    id: 2,
    carName: "Toyota Corolla",
    startDate: "2024-05-01",
    endDate: "2024-05-03",
    price: "45000 Ft",
  },
];

const MyRentals = () => {
  const { data: rentals, isLoading } = useQuery<Rental[]>({
    queryKey: ["rentals"],
    queryFn: () => new Promise<Rental[]>((resolve) => setTimeout(() => resolve(mockRentals), 1000)),
  });

  return (
    <div className="min-h-screen bg-gray-50">
      <Navbar />
      <main className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
        <div className="space-y-6">
          <div className="flex items-center justify-between">
            <h1 className="text-2xl font-bold text-gray-900">Bérléseim</h1>
          </div>

          <Card>
            <CardHeader>
              <CardTitle>Bérlési előzmények</CardTitle>
            </CardHeader>
            <CardContent>
              <Table>
                <TableHeader>
                  <TableRow>
                    <TableHead>Autó</TableHead>
                    <TableHead>Kezdő dátum</TableHead>
                    <TableHead>Záró dátum</TableHead>
                    <TableHead className="text-right">Összeg</TableHead>
                  </TableRow>
                </TableHeader>
                <TableBody>
                  {rentals?.map((rental) => (
                    <TableRow key={rental.id}>
                      <TableCell className="font-medium">{rental.carName}</TableCell>
                      <TableCell>{rental.startDate}</TableCell>
                      <TableCell>{rental.endDate}</TableCell>
                      <TableCell className="text-right">{rental.price}</TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </CardContent>
          </Card>
        </div>
      </main>
    </div>
  );
};

export default MyRentals;
