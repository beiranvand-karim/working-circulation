import { InjectionToken } from '@angular/core'

export const PAGINATION_PAGE_SIZE = new InjectionToken<number>('PAGINATION_PAGE_SIZE', {
  providedIn: 'root',
  factory: () => 8,
})
