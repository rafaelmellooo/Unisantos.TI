import {WeekDay} from "@angular/common";

export interface BusinessHours {
  id: string;
  dayOfWeek: WeekDay;
  openingTime: string;
  closingTime: string;
}
