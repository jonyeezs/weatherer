import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Forecast } from '../models/forecast.type';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import * as moment from 'moment';

interface GetResponse {
  dateUTC: string;
  temperatureC: number;
  climate: string;
  iconUrl: string;
  humidityPercentage: number;
  visibility: number;
  uvIndex: number;
}

@Injectable({
  providedIn: 'root',
})
export class ForecastService {
  private readonly apiPath = 'forecast';

  constructor(private httpClient: HttpClient) {}

  getCurrent(): Observable<Forecast> {
    return this.httpClient
      .get<GetResponse>(`${environment.apiUrl}/${this.apiPath}`)
      .pipe(
        map<GetResponse, Forecast>((v) => ({
          ...v,
          date: new Date(v.dateUTC),
        }))
      );
  }
}
