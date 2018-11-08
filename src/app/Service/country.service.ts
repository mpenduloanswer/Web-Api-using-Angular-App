import { Injectable } from '@angular/core';
import { Sport } from '../Models/Sport';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Country } from '../Models/Country';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
}

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  countrytUrl: string = 'https://localhost:44399/api/country';
  sportUrl: string = 'https://localhost:44399/api/sport';

  constructor(private http: HttpClient) { }

  GetAllSPort(): Observable<Sport[]> {
    return this.http.get<Sport[]>(this.sportUrl);
  }
  GetAllCountries(): Observable<Country[]> {
    return this.http.get<Country[]>(this.countrytUrl);
  }

  addCountry(Country: Country): Observable<Country> {
    // console.log(Country);
    return this.http.post<Country>(this.countrytUrl, Country, httpOptions);
  }
  DeleteCountry(Country: Country): Observable<Country[]> {
    console.log(Country);
    const id = `https://localhost:44399/api/country/${Country.countryID}`;

    return this.http.delete<Country[]>(id, httpOptions);
  }
  editCoun(country: Country): Observable<Country[]> {
    console.log(country);
    const id = `https://localhost:44399/api/country/${country.countryID}`;
    return this.http.put<Country[]>(id, country, httpOptions);
  }
}
