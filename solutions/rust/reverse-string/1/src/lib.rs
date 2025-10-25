pub fn reverse(input: &str) -> String {
    //no semicolon, so this expression is implicitly returned
    input.chars().rev().collect()
}
