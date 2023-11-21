import { Injectable } from '@angular/core';
import { BehaviorSubject} from 'rxjs';
import { IOrder, Order } from '../models/Order.models';

@Injectable({
  providedIn: 'root'
})
export class TransferDataService {
  editable:boolean = false;
  observer = new BehaviorSubject<IOrder>(new Order);

  public subscriber$ = this.observer.asObservable();

  emitData(data:IOrder, editable:boolean)
  {
    this.observer.next(data);
    this.editable = editable
  }
}
