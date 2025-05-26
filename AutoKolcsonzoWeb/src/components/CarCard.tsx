
import React from "react";
import { Button } from "@/components/ui/button";
import { useNavigate } from "react-router-dom";

interface CarCardProps {
  id: number;
  name: string;
  price: number;
  imageUrl: string;
}

const CarCard = ({ id, name, price, imageUrl }: CarCardProps) => {
  const navigate = useNavigate();

  const handleMoreInfo = () => {
    navigate(`/car/${id}`);
  };

  return (
    <div className="bg-white rounded-lg overflow-hidden shadow-sm border border-gray-200">
      <div className="h-48 bg-gray-200 flex items-center justify-center">
        <img
          src={imageUrl}
          alt={name}
          className="h-full w-full object-cover"
        />
      </div>
      <div className="p-4 bg-gray-200">
        <h3 className="text-lg font-medium text-gray-900 text-center">{name}</h3>
        <p className="text-center text-gray-600 mb-3">{price} ft</p>
        <Button 
          className="w-full bg-blue-500 hover:bg-blue-600 text-white rounded-md"
          onClick={handleMoreInfo}
        >
          Több információ
        </Button>
      </div>
    </div>
  );
};
export default CarCard;
