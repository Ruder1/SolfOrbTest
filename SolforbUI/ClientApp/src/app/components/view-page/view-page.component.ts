import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { IOrder, Order } from 'src/app/models/Order.models';
import { TransferDataService } from 'src/app/services/transfer-data.service';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-view-page',
  templateUrl: './view-page.component.html',
  styleUrls: ['./view-page.component.css']
})
export class ViewPageComponent implements OnInit, OnDestroy {

  order:IOrder;
  subscription:Subscription

  constructor(private router:Router,
     private transferService:TransferDataService,
     private orderService: OrderService
     )
  {}
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
  ngOnInit(): void {
    this.subscription = this.transferService.subscriber$.subscribe((data:any)=>{
      this.order = data
    })
  }

  editOrder(item:any)
  {
    // this.appService.emitData(this.order)
    this.router.navigate(['/createEditPage']);
  }

  returnToHomePage()
  {
    this.router.navigate(['/mainPage'])
  }

  deleteOrder()
  {
    console.log(123)
    this.orderService.deleteOrder(this.order.id).subscribe();
    this.returnToHomePage();
  }
}