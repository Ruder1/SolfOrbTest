import { Inject, Injectable } from '@angular/core';
import { IOrder } from '../models/Order.models';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private url = "api/v1/Order/";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {    
  }

  getAllOrders():Observable<IOrder[]>
  {
   var temp = this.http.get<IOrder[]>(environment.apiUrl + this.url + 'Orders');
   return temp;
  }

  createOrder(Order:IOrder)
  {
    return this.http.post(environment.apiUrl + this.url + 'CreateOrder',Order,{observe:'response'})
  }

  updateOrder(Order:IOrder)
  {
    return this.http.put(environment.apiUrl + this.url + 'UpdateOrder',Order,{observe:'response'})
  }

  deleteOrder(id:number)
  {
    return this.http.delete(environment.apiUrl + this.url + 'DeleteOrder/' + id)
  }

  deleteOrderItem(id:number)
  {
    return this.http.delete(environment.apiUrl + 'api/v1/OrderItem/DeleteItem/' + id);
    
  }

}
