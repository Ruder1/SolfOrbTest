export interface IProvider{
    id:number;
    name:string;
}

export interface IOrder{
    id:number;
    number:string;
    date:Date;
    providerId:number
    provider:IProvider;
    orderItem:IOrderItem[];
}

export interface IOrderItem{
    id:number;
    orderId:number;
    name:string;
    quantity:number;
    unit:string;
}

export class Order implements IOrder
{
    provider: IProvider;
    id: number;
    number: string;
    date: Date;
    providerId: number;
    orderItem: IOrderItem[] = [];
}

export class OrderItem implements IOrderItem
{
    id: number;
    orderId: number;
    name: string;
    quantity: number;
    unit: string;

}

// export class Provider implements IProvider
// {
//     id: number;
//     name: string;
//     order: Order[] = [];
    
// }