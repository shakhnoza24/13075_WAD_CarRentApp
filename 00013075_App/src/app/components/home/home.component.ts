import { Component, inject } from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import { CarRental } from '../../CarRental';
import { MatButtonModule } from '@angular/material/button';
import { CarAppService } from '../../car-app.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatTableModule, MatButtonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  router=inject(Router)
  itemList:CarRental[]=[];
  carService=inject(CarAppService); 

  nngOnInit(){
    this.carService.getAll().subscribe((result) => {
      this.itemList = result
    });
  }
  displayedColumns: string[] = ['ID', 'Name', 'Price', 'Renter Name', 'Actions'];
  
  // c(){
  //   console.log("Create")
  //   this.router.navigateByUrl("create")
  // };

  e(id:number){
    console.log("Edit", id)
    this.router.navigateByUrl("edit/"+id)
  };
  dt(id:number){
    console.log("Details", id)
    this.router.navigateByUrl("details/"+id)
  };
  dl(id:number){
    console.log("Delete", id)
    this.router.navigateByUrl("delete/"+id)
  };
}
