import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Sport } from '../Models/Sport';
import { Country} from '../Models/Country'; 
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Tournament } from '../Models/Tournament';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
  }
@Injectable({
  providedIn: 'root'
})
export class TournamentService {
  countrytUrl: string = 'https://localhost:44399/api/country';
  sportUrl: string = 'https://localhost:44399/api/sport';
  tournamentURL: string ='https://localhost:44399/api/Tournament';


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
 AddTournament(Tournament:Tournament): Observable<Tournament>{
       console.log(Tournament);
      return this.http.post<Tournament>(this.tournamentURL, Tournament, httpOptions);
     }

 DeleteTournament(Tournament:Tournament):Observable<Tournament[]>{
    console.log(Tournament);
     const id = `https://localhost:44399/api/Tournament/${Tournament.tournamentID}`;
        
   return this.http.delete<Tournament[]>(id,httpOptions);
 }
 
 EditTournament(Tournament:Tournament): Observable<Tournament[]>{
      console.log(Tournament);
       const id = `https://localhost:44399/api/Tournament/${Tournament.tournamentID}`;
       return this.http.put<Tournament[]>(id, Tournament, httpOptions);
  }
}
