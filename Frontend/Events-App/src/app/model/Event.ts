import { Batch } from "./Batch";
import { Panelist } from "./Panelist";
import { SocialMedia } from "./SocialMedia";

export interface Event {
  id: number
  local: string
  dateEvent?: Date
  theme: string
  numPeople: number
  urlImage: string
  phone: string
  email: string
  batches: Batch[]
  socialMedias: SocialMedia[]
  panelistsEvents: Panelist[]
}
