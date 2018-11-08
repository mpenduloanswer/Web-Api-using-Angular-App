
import { Component, OnInit } from '@angular/core';

import { Country } from '../../Models/Country';
import { CountryService } from 'src/app/Service/country.service';
import { SportService } from 'src/app/sport.service';
import { Sport } from 'src/app/Models/Sport';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.css']
})
export class CountryComponent implements OnInit {

  country: Country[];
  sport: Sport[];
  sportId: number;
  isSelected: Boolean = false;

  constructor(private countryService: CountryService, private sportService: SportService) { }

  ngOnInit() {
    this.getAllCountries();
    this.getSport();
  }

  getSport() {

    this.sportService.GetAllSPort().subscribe(sport => {
    this.sport = sport;
      // console.log(sport);
    });

  }

  getAllCountries() {
    this.countryService.GetAllCountries().subscribe(country => { this.country = country });
  }

  AddCountry(countryName: string, sportID) {
    this.countryService.addCountry({countryName, sportID} as Country).subscribe((country: Country) => this.country.push(country))
  }

  GetSportId(value) {
    this.sportId = value;
    this.isSelected = true;
    console.log(this.isSelected);

    return value;
  }
  removeCountry(Country: Country): void {
    this.countryService.DeleteCountry(Country).subscribe((countries: Country[]) => this.country = countries);
  }

  editCountry(Country: Country, countryName: string) {
    console.log(this.country);
    Country.countryName = countryName;
    this.countryService.editCoun((Country) as Country).subscribe((countries: Country[]) => this.country = countries);
  }

}
