import { Injectable } from '@angular/core';
import { HttpClient , HttpHeaders} from '@angular/common/http';
import { Events } from '../Models/Events';
import { Observable } from 'rxjs';
import { Sport } from '../Models/Sport';
import { Country } from '../Models/Country';
import { Tournament } from '../Models/Tournament';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class EventsService {

  EventURL: string = 'https://localhost:44399/api/event';
  sportUrl: string = 'https://localhost:44399/api/sport';
  tournamentURL: string ='https://localhost:44399/api/Tournament';
  countrytUrl: string = 'https://localhost:44399/api/country';

  constructor(private http: HttpClient) { }

  GetAllSPort():Observable<Sport[]>{
    return this.http.get<Sport[]>(this.sportUrl);
      }
 GetAllCountries():Observable<Country[]>
      {
        return this.http.get<Country[]>(this.countrytUrl);
      }
      GetAllTournament():Observable<Tournament[]>
      {
        return this.http.get<Tournament[]>(this.tournamentURL);
      }

      GetAllEvents():Observable<Events[]>
      {
        return this.http.get<Events[]>(this.EventURL);
      }

      addEvent(event: Events): Observable<Events>
       {
         console.log(event);
         return this.http.post<Events>(this.EventURL, event, httpOptions);
       }

       deleteEvent(event: Events| number): Observable<Events[]>
        {
          const id = typeof event === 'number' ? event : event.eventID;
          console.log(id);
          return this.http.delete<Events[]>(this.EventURL + `/${id}`, httpOptions);
       }
    
        editEvent(event: Events): Observable<Events[]>
        {
          console.log(event);
         return this.http.put<Events[]>(this.EventURL + `/${event.eventID}`, event, httpOptions);
       }

}
