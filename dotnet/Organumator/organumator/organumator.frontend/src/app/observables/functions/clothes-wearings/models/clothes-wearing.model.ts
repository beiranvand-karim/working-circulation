export interface ClothesWearing {
  id: number
  differentiator: string
  wearingStart: string
  wearingFinish: string | null
}

export interface PagedResult<T> {
  items: T[]
  totalCount: number
  pageNumber: number
  pageSize: number
  totalPages: number
}
