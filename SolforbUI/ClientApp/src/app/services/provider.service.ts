import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { IProvider } from '../models/Order.models';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProviderService {
  private url = "api/v1/Provider/";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    
   }

   getAllProviders():Observable<IProvider[]>
   {
    console.log(environment)
    var temp = this.http.get<IProvider[]>(environment.apiUrl + this.url + 'Providers');
    return temp;
   }
}
