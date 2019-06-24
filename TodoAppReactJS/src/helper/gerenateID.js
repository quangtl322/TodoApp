const s1 = () => {
    return Math.floor((1 + Math.random()) * 0x1000).toString(16).substring(1);
};
export const gerenateID = () => {
    return s1() + s1() + "-" + s1() + s1() + s1();
}