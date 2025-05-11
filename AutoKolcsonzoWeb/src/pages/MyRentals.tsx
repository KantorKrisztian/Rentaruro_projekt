
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
  status: string;
  price: string;
}

// Mock rental data - this would typically come from an API
const mockRentals: Rental[] = [
  {
    id: 1,
    carName: "Volkswagen Golf",
    startDate: "2024-04-20",
    endDate: "2024-04-25",
    status: "Aktív",
    price: "75000 Ft",
  },
  {
    id: 2,
    carName: "Toyota Corolla",
    startDate: "2024-05-01",
    endDate: "2024-05-03",
    status: "Függőben",
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

          <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">Aktív bérlések</CardTitle>
                <Package className="h-4 w-4 text-amber-500" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">1</div>
              </CardContent>
            </Card>

            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">Következő bérlés</CardTitle>
                <Calendar className="h-4 w-4 text-amber-500" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">2024.05.01</div>
              </CardContent>
            </Card>
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
                    <TableHead>Státusz</TableHead>
                    <TableHead className="text-right">Összeg</TableHead>
                  </TableRow>
                </TableHeader>
                <TableBody>
                  {rentals?.map((rental) => (
                    <TableRow key={rental.id}>
                      <TableCell className="font-medium">{rental.carName}</TableCell>
                      <TableCell>{rental.startDate}</TableCell>
                      <TableCell>{rental.endDate}</TableCell>
                      <TableCell>{rental.status}</TableCell>
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
