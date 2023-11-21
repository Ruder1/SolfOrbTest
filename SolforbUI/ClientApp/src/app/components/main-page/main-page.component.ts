import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IOrder, Order } from 'src/app/models/Order.models';
import { TransferDataService } from 'src/app/services/transfer-data.service';
import { OrderService } from 'src/app/services/order.service';
import { Subscription } from 'rxjs';
import { DataToFilter, UniqueElements } from 'src/app/models/Filter.models';
import { FilterService } from 'src/app/services/filter.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css'],
})
export class MainPageComponent implements OnInit, OnDestroy {
  Orders: IOrder[] = [];
  mySubscription:Subscription
  uniqueElements:UniqueElements = new UniqueElements();
  dataToFilter:DataToFilter = new DataToFilter();

  constructor(
    private router: Router,
    private orderService: OrderService,
    private TransferService: TransferDataService,
    private filterService:FilterService
  ) {}
  
  ngOnDestroy(): void {
    this.mySubscription.unsubscribe();
  }

  ngOnInit(){

    this.filterService.getUniqueElements().subscribe((result)=>
    {
      this.uniqueElements = result;
    })

    this.mySubscription = this.orderService.getAllOrders().subscribe((result) => {
      this.Orders = result;
    });

    this.dataToFilter.previousDate = this.PreviousMonth();
    this.dataToFilter.currentDate = this.CurrentMonth();
  }

  PreviousMonth() {
    var date = new Date();
    var result = '';
    result =
      date.getFullYear().toString() +
      '-' +
      date.getMonth().toString() +
      '-' +
      date.getDate().toString();

    return  result;
  }

  CurrentMonth() {
    var date = new Date();
    var result = '';
    result =
      date.getFullYear().toString() +
      '-' +
      (date.getMonth() + 1).toString() +
      '-' +
      date.getDate().toString();

    return result;
  }

  viewOrderInfo(item: any) {
    this.TransferService.emitData(item,true);
    this.router.navigate(['/viewPage']);
  }

  createNewOrder()
  {
    this.TransferService.emitData(new Order(),false);
    this.router.navigate(['/createEditPage'])
  }
  
  check()
  {
    this.filterService.getFiltredData(this.dataToFilter).subscribe((result)=>
    {
      this.Orders = result;
    }
    )
  }
}
