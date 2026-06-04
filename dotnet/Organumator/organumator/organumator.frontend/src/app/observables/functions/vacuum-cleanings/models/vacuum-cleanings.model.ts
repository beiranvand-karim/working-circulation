export interface VacuumCleanings {
  id: number
  performedOnDate: string
}

export interface PagedResult<T> {
  items: T[]
  totalCount: number
  pageNumber: number
  pageSize: number
  totalPages: number
}
