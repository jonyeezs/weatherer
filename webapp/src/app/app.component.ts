import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Forecast } from './models/forecast.type';
import { ForecastService } from './services/forecast.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  currentWeather$: Observable<Forecast>;

  constructor(private forecastSvc: ForecastService) {}
  ngOnInit(): void {
    this.currentWeather$ = this.forecastSvc.getCurrent();
  }
}
