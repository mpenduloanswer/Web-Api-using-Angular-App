import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Sport} from './Models/Sport';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
  }
  
@Injectable({

  providedIn: 'root'
  
})
export class SportService {

  sportUrl: string = 'https://localhost:44399/api/sport';
  constructor(private http: HttpClient) { }

GetAllSPort():Observable<Sport[]>{
return this.http.get<Sport[]>(this.sportUrl);
}
  
 addSport(sport:Sport): Observable<Sport>{
 console.log(sport);
 return this.http.post<Sport>(this.sportUrl, sport, httpOptions);
  
    }
  DeleteSport(sport:Sport):Observable<Sport>{
  console.log(sport);
  const id = `https://localhost:44399/api/sport/${sport.sportID}`;
      
  return this.http.delete<Sport>(id,httpOptions);

      }

 editSport(sport:Sport): Observable<Sport>{
   console.log(sport);
   const id = `https://localhost:44399/api/sport/${sport.sportID}`;
   return this.http.put<Sport>(id, sport, httpOptions);
}
}