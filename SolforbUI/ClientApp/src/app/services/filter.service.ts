import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IOrder } from '../models/Order.models';
import { UniqueElements, DataToFilter } from '../models/Filter.models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FilterService {

  private url = "api/v1/Filter/";

  constructor(private http: HttpClient) {    
  }

  getUniqueElements():Observable<UniqueElements>
  {
    return this.http.get<UniqueElements>(environment.apiUrl + this.url + 'UniqueElements')
  }

  getFiltredData(data:DataToFilter):Observable<IOrder[]>
  {
    return this.http.post<IOrder[]>(environment.apiUrl+ this.url + 'FilterData',data)
  }
}
