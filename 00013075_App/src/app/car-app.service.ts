import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { CarRental } from './CarRental';

@Injectable({
  providedIn: 'root'
})
export class CarAppService {
  createItem(itemIssue: any) {
    throw new Error('Method not implemented.');
  }
  httpClient = inject(HttpClient);

  constructor() { }

  getAll(){
    return this.httpClient.get<CarRental[]>("https://localhost:7183/api/Cars/Getcars");
  };

  
}
