export const makeRoute = (url: string | ((data?: any) => void), title?: string, icon?: string) => {
    return {
        URL: url,
        TITLE: title ?? "",
        ICON: icon ?? ""
    }
}