export interface ButtonConfig {
    action: (data: any) => void
    icon?: string
    label: string
    permissions?: string[]
    showAlways?: boolean
    condition?: (data: any) => boolean,
    type?: string
  }