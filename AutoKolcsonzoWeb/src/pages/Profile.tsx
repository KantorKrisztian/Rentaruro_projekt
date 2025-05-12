
import React from "react";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import { Label } from "@/components/ui/label";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { UserCog } from "lucide-react";
import Navbar from "@/components/Navbar";

const Profile = () => {
  return (
    <div className="min-h-screen bg-gray-50">
      <Navbar />
      <div className="max-w-4xl mx-auto p-6">
        <div className="mb-8">
          <h1 className="text-3xl font-bold text-gray-900">Profil</h1>
          <p className="text-gray-600">Felhasználói adatok kezelése</p>
        </div>

        <div className="grid gap-6 mb-8">
          <Card>
            <CardHeader className="space-y-1">
              <CardTitle className="text-2xl flex items-center gap-2">
                <UserCog className="h-6 w-6" />
                Személyes adatok
              </CardTitle>
            </CardHeader>
            <CardContent className="grid gap-4">
              
              <div className="grid gap-4">
                <div className="grid gap-2">
                  <Label htmlFor="name">Teljes név</Label>
                  <Input id="name" placeholder="Vezetéknév Keresztnév" />
                </div>
                
                <div className="grid gap-2">
                  <Label htmlFor="email">Email cím</Label>
                  <p id="email"  className="block w-full" ></p>
                </div>
                
                <div className="grid gap-2">
                  <Label htmlFor="phone">Telefonszám</Label>
                  <Input id="phone" type="tel" placeholder="+36 XX XXX XXXX" />
                </div>

                <Button className="w-full">Mentés</Button>
              </div>
            </CardContent>
          </Card>

          <Card>
            <CardHeader>
              <CardTitle>Bérlési előzmények</CardTitle>
            </CardHeader>
            <CardContent>
              <p className="text-gray-600">Még nincs korábbi bérlésed.</p>
            </CardContent>
          </Card>
        </div>
      </div>
    </div>
  );
};

export default Profile;
