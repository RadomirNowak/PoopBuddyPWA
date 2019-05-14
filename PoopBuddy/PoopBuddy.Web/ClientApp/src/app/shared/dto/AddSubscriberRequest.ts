export class AddSubscriberRequest {
  endpoint: string;
  expirationTime: number;
  keys: {
    p256dh: string;
    auth: string;
  }
}
