export interface CarRental{
    id:number,
    name:string,
    price:number,
    renterId:number,
    renter:{
        id:number,
        fullName:string
    }
}