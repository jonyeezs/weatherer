import { Moment } from 'moment';

export interface Forecast {
  date: Moment;
  temperatureC: number;
}
