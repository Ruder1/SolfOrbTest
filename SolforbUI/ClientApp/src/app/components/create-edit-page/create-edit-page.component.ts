import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormArray, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {
  IOrder,
  IOrderItem,
  IProvider,
  OrderItem,
} from 'src/app/models/Order.models';
import { TransferDataService } from 'src/app/services/transfer-data.service';
import { OrderService } from 'src/app/services/order.service';
import { ProviderService } from 'src/app/services/provider.service';
import {
  HttpErrorResponse,
  HttpHeaderResponse,
  HttpResponse,
} from '@angular/common/http';

@Component({
  selector: 'app-create-edit-page',
  templateUrl: './create-edit-page.component.html',
  styleUrls: ['./create-edit-page.component.css'],
})
export class CreateEditPageComponent implements OnInit {
  order: IOrder;
  orderForm: FormGroup;

  isUnique = true;

  providers: IProvider[] = [];

  constructor(
    private transferService: TransferDataService,
    private providerService: ProviderService,
    private router: Router,
    private orderService: OrderService
  ) {
    this.orderForm = new FormGroup({
      orderNumber: new FormControl<string>('', Validators.required),
      orderDate: new FormControl('', Validators.required),
      orderProvider: new FormControl('', Validators.required),
      orderItems: new FormArray([]),
    });
  }

  ngOnInit(): void {
    this.transferService.subscriber$.subscribe((data: any) => {
      this.order = data;
    });
    this.providerService.getAllProviders().subscribe((data: any) => {
      this.providers = data;
    });

    this.InitializeForm();
  }

  InitializeForm() {
    this.orderForm.patchValue({
      orderNumber: this.order.number,
      orderDate: this.order.date,
      orderProvider: this.order.provider,
    });
    if (this.order.orderItem.length > 0) {
      this.order.orderItem.forEach((element) => {
        var orderItem = new FormGroup({
          orderItemQuantity: new FormControl(
            element.quantity,
            Validators.required
          ),
          orderItemUnit: new FormControl(element.unit, Validators.required),
          orderItemName: new FormControl(element.name, Validators.required),
          orderItemId: new FormControl(element.id, Validators.required),
        });
        (<FormArray>this.orderForm.get('orderItems')).push(orderItem);
      });
    } else {
      this.onAddNewOrderItem();
    }
  }

  saveOrder() {
    this.assigmentData();

    var errorMessage: string = "";
    var responseMessage: HttpResponse<any>;

    if (this.transferService.editable) {
      this.orderService.updateOrder(this.order).subscribe({
        next: (data: HttpResponse<any>) => {
          responseMessage = data;
        },
        error: (error:HttpErrorResponse) => {
          errorMessage = error.error;
        },
      });
      console.log('edit');
    } else {
      this.orderService.createOrder(this.order).subscribe({
        next: (data: HttpResponse<any>) => {
          responseMessage = data;
        },
        error: (error: HttpErrorResponse) => {
          console.log(error);
          errorMessage = error.error;          
        },
      });
      console.log('create');
    }
      
    setTimeout(() => {
      if (errorMessage.includes('Number')) {
        this.isUnique = false;
      }
      console.log(this.isUnique)
      if (responseMessage.status == 200) {
        this.router.navigate(['/mainPage']);
      }
    }, 500);
  }

  assigmentData() {
    if (this.orderForm.value.orderProvider == undefined) {
      this.orderForm.patchValue({
        orderProvider: this.providers[0],
      });
      this.order.provider = this.providers[0];
    }

    this.order.date = this.orderForm.value.orderDate;
    this.order.number = this.orderForm.value.orderNumber;
    this.order.providerId = this.order.provider.id;

    var temp = this.orderFormArray.value;
    this.order.orderItem.splice(0, this.order.orderItem.length);
    for (let index = 0; index < temp.length; index++) {
      var orderItem: OrderItem = new OrderItem();
      var element = temp[index];

      orderItem.name = element.orderItemName;
      orderItem.unit = element.orderItemUnit;
      orderItem.quantity = element.orderItemQuantity;

      if (element.orderItemId == undefined) {
        orderItem.id = 0;
      } else {
        orderItem.id = element.orderItemId;
      }

      this.order.orderItem.push(orderItem);
    }
  }

  getFormsControls(): FormArray {
    return this.orderForm.controls['orderItems'] as FormArray;
  }

  onAddNewOrderItem() {
    var orderItem = new FormGroup({
      orderItemQuantity: new FormControl('', Validators.required),
      orderItemUnit: new FormControl('', Validators.required),
      orderItemName: new FormControl('', Validators.required),
    });
    this.orderFormArray.push(orderItem);
  }

  changeOrderProvider() {
    let index = this.providers.findIndex(
      (n) => n.id === parseInt(this.orderForm.value.orderProvider[0])
    )!;
    this.order.provider = this.providers[index];
  }

  cancelEdit() {
    this.router.navigate(['/mainPage']);
  }

  removeItem() {
    if (this.orderFormArray.length > 1) {
      var index = this.orderFormArray.at(this.orderFormArray.length - 1);
      this.orderFormArray.removeAt(this.orderFormArray.length - 1);
      // this.orderService.deleteOrderItem(index.value.orderItemId).subscribe();
    }
  }

  get orderFormArray(): FormArray {
    return this.orderForm.get('orderItems') as FormArray;
  }
}
