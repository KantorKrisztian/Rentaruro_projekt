
import React from "react";
import { X } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Textarea } from "@/components/ui/textarea";
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
} from "@/components/ui/dialog";

interface RentalDialogProps {
  open: boolean;
  onOpenChange: (open: boolean) => void;
  carName: string;
}

const RentalDialog = ({ open, onOpenChange, carName }: RentalDialogProps) => {
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onOpenChange(false);
  };

  return (
    <Dialog open={open} onOpenChange={onOpenChange}>
      <DialogContent className="sm:max-w-md">
        <DialogHeader>
          <DialogTitle className="text-center font-bold">Gépjármű foglalása</DialogTitle>
        </DialogHeader>
        
        <div className="border-t border-b py-2 my-2">
          <h3 className="text-center font-semibold">{carName}</h3>
        </div>
        
        <form onSubmit={handleSubmit}>
          <div className="space-y-4 py-2">
            <div className="space-y-2">
              <label className="text-sm font-medium">Bérlés kezdete:</label>
              <Input type="date" required />
            </div>
            
            <div className="space-y-2">
              <label className="text-sm font-medium">Bérlés vége:</label>
              <Input type="date" required />
            </div>
            
            <div className="space-y-2">
              <label className="text-sm font-medium">Egyéb bérlési információk:</label>
              <Textarea 
                placeholder="Adjon meg további információkat a bérlésről..."
                className="min-h-[100px]"
              />
            </div>
            
            <Button 
              type="submit" 
              className="w-full bg-orange-500 hover:bg-orange-600 text-white"
            >
              Foglalás véglegesítése
            </Button>
          </div>
        </form>
      </DialogContent>
    </Dialog>
  );
};

export default RentalDialog;
