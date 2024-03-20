import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { CarAppService } from '../../car-app.service';

@Component({
  selector: 'app-crete',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatSelectModule, FormsModule, MatButtonModule],
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})
export class CreateComponent {
  carService = inject(CarAppService)
  router = inject(Router)

  renters:any

  itemCar: any ={
    name:"",
    price: 0,
    renterID: 0
  }

  selectedRenterID: number=0

  ngOnInit(){
    this.carService.getAll().subscribe(result=>{
      this.renters = result
    });
  }

  onCreateBtn(){
    this.itemCar.renterID = this.selectedRenterID
    this.carService.createItem(this.itemCar).subscribe(result => {
      console.log(result)
      alert("Created")
      this.router.navigateByUrl("home")
    })
  }
}
