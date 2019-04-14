import { Time } from "../../shared/time/Time";

export interface IPooping {
  externalId: string;
  authorName: string;
  duration: Time;
  durationInMs: number;
  wagePerHour: number;
}