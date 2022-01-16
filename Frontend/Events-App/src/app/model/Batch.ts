import { Event } from "./Event";

export interface Batch {
  id: string
  name: string
  price: number
  inicialDate?: Date
  finalDate?: Date
  quantity: number
  eventId: number
  event?: Event
}
