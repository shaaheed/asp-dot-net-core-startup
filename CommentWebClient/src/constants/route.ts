export const makeRoute = (url: string, title?: string, icon?: string) => {
    return {
        URL: url,
        TITLE: title ?? "",
        ICON: icon ?? ""
    }
}