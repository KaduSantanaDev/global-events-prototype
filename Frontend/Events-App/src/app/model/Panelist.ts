import { SocialMedia } from './SocialMedia';
import { Event } from './Event'
export interface Panelist {
  id: number
  name: string
  description: string
  urlImage: string
  phone: string
  email: string
  socialMedias: SocialMedia[]
  panelistsEvents: Event[]
}
