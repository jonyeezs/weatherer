export interface Forecast {
  date: Date;
  temperatureC: number;
  climate: string;
  iconUrl: string;
  humidityPercentage: number;
  visibility: number;
  uvIndex: number;
}
